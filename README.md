# 💻 Estudos sobre .NET 📚
Este é um repositório dedicado ao estudo da plataforma .NET. Utilizo este repositório para consulta de dúvidas pessoais porém achei oportuno deixar público para de alguma forma ajudar a comunidade.

## Sumário
1. 💾 Banco de Dados com Dapper

## 💾 Banco de Dados com Dapper:
- Instalando o Dapper
  - Para utilizar o Dapper, é necessário ter instalado o pacote Microsoft.Sql.Client. Após isso, podemos instalar o Dapper, utilizando o comando: <b> dotnet add package Dapper </b>. A versão utilizada para os estudos foi a 2.0.90.
- Criando a String de Conexão
  - Para iniciarmos nossas consultas, precisamos nos conectar ao banco de dados. Para isso, podemos declarar uma constante com o nome de "connectionString" com as informações necessárias para realizar a conexão, utilizando o seguinte padrão: <br>
  <b>1. Server, Port:</b> O número IP do seu servidor seguido de uma vírgula e o número da porta de acesso, no caso do SQL Server, a 1433.<br>
  <b>2. Database:</b> O nome do banco de dados.<br>
  <b>3. User e Password:</b> Simples, o usuário e senha de acesso ao seu BD. Caso você tenha feito autenticação com o Windows, deve ser substituídos os campos User e Password apenas por: Integrated Security=true. A seguinte string deve ser formada: <br><br>
  <b>const string connectionString = "Server=localhost,1433; Database=DBName;User=sa;Password=root";</b><br><br>
  Segue uma imagem ilustrativa do que temos até agora: <br><br>
  ![image](https://user-images.githubusercontent.com/65985740/218146194-51558e24-557e-43a6-ad2b-063b7ef449ff.png)
  
 - Iniciando a conexão
  - Para realizarmos nossa conexão, precisamos criar uma instancia da classe <b>SqlConnection</b> do pacote Microsoft.Sql.Client. Segue a imagem: <br><br>
 ![image](https://user-images.githubusercontent.com/65985740/218148533-be0b0900-b271-4f77-a7f6-6354ff3b5eef.png)

