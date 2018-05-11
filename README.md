# bliss-api

Bliss Recruitment API

Steps to setup and run the software:

- In SQL Server Management Studio, create new database with this name: Bliss.Recruitment
- In web.config file in Bliss.Recruitment.Api project, change this line for correct server name:

  ```xml
  <connectionStrings>
    <add name="DbContext" connectionString="Data Source=<SERVER_NAME>;Initial Catalog=Bliss.Recruitment;Integrated Security=SSPI"   providerName="System.Data.SqlClient" />
  </connectionStrings>
  ```
  
- To setup database tables, execute the following scripts (in this order) located in Bliss.Recruitment.Database project:

  - Question.sql

  - QuestionChoice.sql


And that's all!
