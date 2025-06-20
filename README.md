# GestaoDispositivos

Sobre o projeto
Esta API, desenvolvida utilizando .NET 8, adota os princípios do Domain-Driven Design (DDD) para oferecer uma solução estruturada e eficaz no gerenciamento de  uma API    que gerenciar clientes, dispositivos e eventos
recebidos desses dispositivos.
A arquitetura da API baseia-se em REST, utilizando métodos HTTP padrão para uma comunicação eficiente e simplificada. Além disso, é complementada por uma documentação Swagger, que proporciona uma interface gráfica interativa para que os desenvolvedores possam explorar e testar os endpoints de maneira fácil.

Dentre os pacotes NuGet utilizados, o AutoMapper é o responsável pelo mapeamento entre objetos de domínio e requisição/resposta, reduzindo a necessidade de código repetitivo e manual. Para as validações, o FluentValidation é usado para implementar regras de validação de forma simples e intuitiva nas classes de requisições, mantendo o código limpo e fácil de manter. Por fim, o EntityFramework atua como um ORM (Object-Relational Mapper) que simplifica as interações com o banco de dados, permitindo o uso de objetos .NET para manipular dados diretamente, sem a necessidade de lidar com consultas SQL.

Features
Domain-Driven Design (DDD): Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
RESTful API com Documentação Swagger: Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.
Construído com

Getting Started
Para obter uma cópia local funcionando, siga estes passos simples.

Requisitos
Visual Studio versão 2022+
Windows 10+ ou Linux/MacOS com .NET SDK instalado
Sql Server

Instalação
Clone o repositório:

git clone https://github.com/marcosviniciusjau/GestaoDispositivos.git
Preencha as informações no arquivo appsettings.Development.json: {
  "ConnectionStrings": {
    "Connection": "Server=Seu servidor;Database=gestao_dispositivos;User Id=sa;Password=Sua Senha&;TrustServerCertificate=True;"
  },
  "Settings": {
    "Jwt": {
      "SigningKey": "Chave JWT",
      "ExpiresMinutes": 1000
    }
  }
}

Migrações
Antes de começar a rodar a aplicação rode o comando na pasta src: dotnet ef migrations add nome_migracao --project src/GestaoDispositivos.Infra --startup-project src/GestaoDispositivos.API
Execute a API
