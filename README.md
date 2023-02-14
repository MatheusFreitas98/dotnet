# 💻 Estudos sobre .NET 📚
Este é um repositório dedicado ao estudo da plataforma .NET. Utilizo para consultas de dúvidas pessoais, como um "memorex", então está tudo de forma bem resumida. Decidi tornar público para que possa de alguma forma ajudar a comunidades dos Devs .NET.

## Sumário
1. 💾 Banco de Dados com Dapper

## 💾 Banco de Dados com Dapper:


- ### Instalando o Dapper
  - Para utilizar o Dapper, é necessário ter instalado o pacote Microsoft.Sql.Client. A versão utilizada no projeto foi a 2.1.3 (outras versões deram problemas na autenticação).<br><br>
    - Instalando Microsoft.Sql.Client: <br>
    <b> > dotnet add package Microsoft.Data.Sqlclient --version 2.1.3</b>
    - Instalando o Dapper: <br>
    <b> > dotnet add package Dapper </b>
    <br>

- ### Criando a String de Conexão
  - Cria-se a connectionString no seguinte formato: <br>
<b>const string connectionString = "Server=localhost,1433; Database=DBName;User=sa;Password=root";</b><br><br>
Onde: <br>
  <b>1. Server, Port:</b> O número IP do seu servidor seguido de uma vírgula e o número da porta de acesso, no caso do SQL Server, a 1433.<br>
  <b>2. Database:</b> O nome do banco de dados.<br>
  <b>3. User e Password:</b> Simples, o usuário e senha de acesso ao seu BD. Caso você tenha feito autenticação com o Windows, deve ser substituídos os campos User e Password apenas por: Integrated Security=true. A seguinte string deve ser formada: <br>
  
  Segue uma imagem ilustrativa do que temos até agora: <br><br>
  ![image](https://user-images.githubusercontent.com/65985740/218146194-51558e24-557e-43a6-ad2b-063b7ef449ff.png)
  <br><br>
  
- ### Iniciando a conexão
  - Para realizarmos nossa conexão, precisamos criar uma instancia da classe <b>SqlConnection</b> do pacote <b>Microsoft.Sql.Client</b>. Para evitar a necessidade de abrir e encerrar a conexão, podemos utilizar o bloco <b>using</b> do C#. Como parâmetro, passamos a conexão criada anteriormente. Segue o exemplo: <br><br>
![image](https://user-images.githubusercontent.com/65985740/218195473-4d5324b0-d272-416f-8658-ead4cb689ee1.png)
<br><br>

- ### Executando a query
  - Utilizando a instancia do <b>SqlConnection</b> e chamando o método <b>.Query</b> do Dapper (já importado) passando como parâmetro a nossa query, temos o seguinte resultado: <br><br>
![image](https://user-images.githubusercontent.com/65985740/218197595-b8ac2acb-b387-4cc3-a673-bea917608d67.png)<br><br>
  - Obs: O Dapper irá retornar um IEnumerable do tipo dynamic nessa execução. Esse tipo dynamic pode ser qualquer outro tipo, inclusive Category, bastando tipá-lo: <br><br>
 ![image](https://user-images.githubusercontent.com/65985740/218198851-e8bc7960-ce7f-4218-b0e6-612b07c9e8cc.png)<br><br>
  - Finalmente, usando um <b>forEach</b> para percorrer a lista tipada com os dados consulta: <br><br>
 ![image](https://user-images.githubusercontent.com/65985740/218200501-7c2dce6a-4080-4556-bfb3-deb61ec6872e.png)
