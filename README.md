# 💻 Estudos sobre .NET 📚
Este é um repositório dedicado ao estudo da plataforma .NET. Utilizo este repositório para consulta de dúvidas pessoais porém achei oportuno deixar público para de alguma forma ajudar a comunidade.

## Sumário
1. 💾 Banco de Dados com Dapper

## 💾 Banco de Dados com Dapper:
- Instalando o Dapper
  - Para utilizar o Dapper, é necessário ter instalado o pacote Microsoft.Sql.Client. Após isso, podemos instalar o Dapper, utilizando o comando: <b> dotnet add package Dapper </b>. A versão utilizada para os estudos foi a 2.0.90.
- Criando a String de Conexão
  - Para iniciarmos nossas consultas, precisamos nos conectar ao banco de dados. Para isso, podemos declarar uma constante com o nome de "connectionString" com as informações necessárias para realizar a conexão, utilizando o seguinte padrão: <br><br>
  <b>1. Server, Port:</b> O número IP do seu servidor seguido de uma vírgula e o número da porta de acesso, no caso do SQL Server, a 1433.<br>
  <b>2. Database:</b> O nome do banco de dados.<br>
  <b>3. User e Password:</b> Simples, o usuário e senha de acesso ao seu BD. Caso você tenha feito autenticação com o Windows, deve ser substituídos os campos User e Password apenas por: Integrated Security=true. A seguinte string deve ser formada: <br><br>
  <b>const string connectionString = "Server=localhost,1433; Database=DBName;User=sa;Password=root";</b><br><br>
  Segue uma imagem ilustrativa do que temos até agora: <br><br>
  ![image](https://user-images.githubusercontent.com/65985740/218146194-51558e24-557e-43a6-ad2b-063b7ef449ff.png)
  
- Iniciando a conexão
  - Para realizarmos nossa conexão, precisamos criar uma instancia da classe <b>SqlConnection</b> do pacote <b>Microsoft.Sql.Client</b>. Para evitar a necessidade de abrir e encerrar a conexão, podemos utilizar o bloco <b>using</b> do C#. Como parâmetro, passamos a conexão criada anteriormente. Segue o exemplo: <br><br>
![image](https://user-images.githubusercontent.com/65985740/218195473-4d5324b0-d272-416f-8658-ead4cb689ee1.png)

- Executando a query
  - Para isso, podemos simplesmente utilizar a nossa instancia do <b>SqlConnection</b> e chamar o método <b>.Query</b> do Dapper (já importado) passando como parâmetro a nossa query.<br><br>
![image](https://user-images.githubusercontent.com/65985740/218197595-b8ac2acb-b387-4cc3-a673-bea917608d67.png)<br><br>
  - Aqui vem uma observação: O Dapper irá retornar um IEnumerable do tipo dynamic nessa execução. Isso irá facilitar nosso trabalho de diversas formas. Para obtermos mais vantagens, podemos tipar nosso IEnumerable para o tipo de categoria. Veja:<br><br>
 ![image](https://user-images.githubusercontent.com/65985740/218198851-e8bc7960-ce7f-4218-b0e6-612b07c9e8cc.png)<br><br>
  - Agora, podemos simplesmente usar um <b>forEach</b> e percorremos a nossa lista tipada. Legal, né? Veja a seguir:<br><br>
 ![image](https://user-images.githubusercontent.com/65985740/218200501-7c2dce6a-4080-4556-bfb3-deb61ec6872e.png)

 



