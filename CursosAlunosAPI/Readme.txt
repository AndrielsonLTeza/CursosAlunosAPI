Passo 1: Instale o .NET SDK (versão 7.0 ou superior) se ainda não tiver

Baixe em: https://dotnet.microsoft.com/download


Instale as extensões do VS Code:

C# Dev Kit (Microsoft)
C# (Microsoft)
.NET Core Tools


Passo 2: Adicione os pacotes necessários

Instale o pacote do Swagger (se não estiver incluído por padrão):
bashdotnet add package Swashbuckle.AspNetCore




Passo 3: Execute e teste a API

Compile o projeto:
bashdotnet build

Execute a aplicação:
bashdotnet run

3.Acesse o Swagger para testar a API:

Abra o navegador e acesse: https://localhost:[porta]/swagger