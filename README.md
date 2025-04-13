Sistema de Gerenciamento de Cursos e
Alunos em .NET

Este documento apresenta dois enunciados para a criação de um sistema de gerenciamento de cursos e alunos

utilizando .NET com C#, abordando duas implementações diferentes: Minimal API e Controller padrão.

Comparação entre Minimal API e Controller

Padrão

Enunciado 2 4 Controladores (Padrão tradicional)

Você deve criar uma aplicação .NET com C Sharp, utilizando a estrutura tradicional com controladores
(Controllers) para representar um sistema de gerenciamento de cursos e alunos.
Requisitos

Modelos

Crie as classes Aluno e Curso.

Um Curso pode conter vários Alunos.

Um Aluno pertence a um Curso.

Camadas

Modelos com as entidades.

Repositórios para simular persistência (in-memory).

Serviços para isolar a lógica de negócio.

Controladores para expor os endpoints via API.

Operações

CRUD completo para Curso e Aluno.

Endpoint específico para matricular um aluno em um curso.

Todos os endpoints devem seguir o padrão REST:

GET /api/cursos

GET /api/alunos

POST /api/alunos

etc.

Tecnologias

Use .NET 7 ou superior.

Organize o projeto com separação clara das camadas.

Utilize os atributos [ApiController] e [Route("api/[controller]")].

Extras (opcional)

Implemente respostas adequadas com NotFound, BadRequest, Created, etc.

Pode utilizar DTOs para separar a exposição da modelagem interna, se desejar
