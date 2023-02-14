using Microsoft.Data.SqlClient;
using Dapper.Model;
using Dapper;
using System.Data;

var connection = new SqlConnection("Server=localhost,1433;Database=balta ;Integrated Security=true");



Console.WriteLine("Aplicação Rodando...");

using (connection)
{
    // CreateCategory(connection, category);

    // ListCategories(connection);

    // UpdateCategory(connection);

    // DeleteCategory(connection);

    // ListCategories(connection);

    // ExecuteProcedureSelect(connection);

    // ExecuteScalar(connection);

    // VwListCourses(connection);

    // OneToOne(connection);

    OneToMany(connection);


}

static void ListCategories(SqlConnection connection)
{
    var categories = connection.Query<Category>("SELECT Id, Title FROM Category");

    foreach (var category in categories)
    {
        Console.WriteLine($"ID da categoria: {category.Id} - Título da categoria: {category.Title}");
    }
}

static void CreateCategory(SqlConnection connection)
{
    Category categoria = new Category();
    categoria.Id = Guid.NewGuid();
    categoria.Title = "Amazon AWS";
    categoria.Url = "amazon";
    categoria.Description = "Categoria destinada a serviços do AWS";
    categoria.Order = 8;
    categoria.Summary = "Aws Cloud";
    categoria.Featured = false;

    var rows = 0;
    var insertQuery = @"INSERT INTO 
                            Category 
                        VALUES (
                            @Id,
                            @Title,
                            @Url,
                            @Description,
                            @Order,
                            @Summary,
                            @Featured
                        )";
    rows = connection.Execute(insertQuery, new
    {
        categoria.Id,
        categoria.Title,
        categoria.Url,
        categoria.Description,
        categoria.Order,
        categoria.Summary,
        categoria.Featured
    });
    Console.WriteLine(rows);
}

static void UpdateCategory(SqlConnection connection)
{
    Category category = new Category();
    category.Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4");
    category.Title = "Frontend 2023";



    var updateQuery = @"UPDATE Category
                            SET Title = @Title
                            WHERE Id = @Id";

    var rows = connection.Execute(updateQuery, new
    {
        category.Id,
        category.Title
    });

    Console.WriteLine($"{rows} registros atualizados.");
}

static void DeleteCategory(SqlConnection connection)
{
    var deleteQuery = @"DELETE FROM Category WHERE Id = @Id";

    var rows = connection.Execute(deleteQuery, new
    {
        Id = "e2b54a13-c900-4218-bc70-e4e053c04c23"
    });

    Console.WriteLine($"{rows} registros deletados.");
}

static void ExecuteProcedureSelect(SqlConnection connection)
{ // Read e Execute
    var executeProcSelect = "spSelectStudent";

    var StudentIdzera = new
    {
        StudentId = "ecdf9746-dcac-470c-ad2f-6bc4a57edc50",
    };

    Guid StudentId = new Guid("ecdf9746-dcac-470c-ad2f-6bc4a57edc50");

    var rows = connection.Query(executeProcSelect, StudentIdzera, commandType: CommandType.StoredProcedure);

    foreach (var item in rows)
    {
        Console.WriteLine(item);
    }
}

static void ExecuteScalar(SqlConnection connection)
{
    Category categoria = new Category();
    categoria.Title = "Amazon AWS";
    categoria.Url = "amazon";
    categoria.Description = "Categoria destinada a serviços do AWS";
    categoria.Order = 8;
    categoria.Summary = "Aws Cloud";
    categoria.Featured = false;

    var queryExecuteScalar = @"
                                DECLARE @NewId uniqueidentifier;
                                SET @NewId = NEWID();
                                INSERT INTO
                                Category
                            VALUES (
                                @NewId,
                                @Title,
                                @Url,
                                @Description,
                                @Order,
                                @Summary,
                                @Featured
                            );
                            SELECT @NewId;";

    var idExecuteScalar = connection.ExecuteScalar<Guid>(queryExecuteScalar, new
    {
        categoria.Title,
        categoria.Url,
        categoria.Description,
        categoria.Order,
        categoria.Summary,
        categoria.Featured
    });

    Console.WriteLine(idExecuteScalar);
};

static void VwListCourses(SqlConnection connection)
{
    var vwListCourses = "SELECT * FROM vwCourses";

    var courses = connection.Query<Course>(vwListCourses);

    foreach (var course in courses)
    {
        Console.WriteLine($"{course.Title} - {course.Summary}");
    }
}

static void OneToOne(SqlConnection connection)
{
    var sql = "SELECT * FROM CareerItem INNER JOIN Course ON CareerItem.CourseId = Course.Id";

    var careers = connection.Query<CareerItem, Course, CareerItem>(sql,
            (careerItem, course) =>
            {
                careerItem.Course = course;
                return careerItem;
            },
            splitOn: "Id");

    foreach (var item in careers)
    {
        Console.WriteLine($"{item.Course.Title} - {item.Description}");
    }
}

static void OneToMany(SqlConnection connection)
{
    var sql = @"SELECT
                    Career.Id,
                    Career.Title,
                    CareerItem.CareerId,
                    CareerItem.Title
                FROM
                    Career
                INNER JOIN
                    CareerItem
                ON
                    CareerItem.CareerId = Career.Id
                ORDER BY
                    Career.Title";

    var careers = new List<Career>();

    var items = connection.Query<Career, CareerItem, Career>(sql,
            (career, item) =>
            {
                var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();

                if (car == null) {
                    car = career;
                    car.CareerItems = car.CareerItems ?? new List<CareerItem>();
                    car.CareerItems.Add(item);
                    careers.Add(car);
                }
                else {
                    car.CareerItems = car.CareerItems ?? new List<CareerItem>();
                    car.CareerItems.Add(item);
                }
                return career;
            },
            splitOn: "CareerId");

    foreach (var career in items)
    {
        Console.WriteLine($"{career.Title}");
        foreach (var item in career.CareerItems)
        {
            Console.WriteLine($" - {item.Title}");
        }
    }
}