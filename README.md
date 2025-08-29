# DIO_SERIES 📺
Projeto criado a partir do bootcamp da GFT START #2 .NET - Cadastro de Séries.
Aplicação desenvolvida como projeto de estudo para fixar conceitos de **Programação Orientada a Objetos (POO)**, **SOLID** e **Design Patterns**.  
O objetivo é simular um pequeno **catálogo de séries**, permitindo **cadastrar, listar, atualizar, excluir e visualizar** informações sobre séries.

---

## Programinha: Cadastro de Séries 💻

__*Funções e Objetivos:*__
Como forma de aprendizado com o framework .NET, foi proposto um CRUD em memória, <br> 
com os ensinamentos do professor Eliézer(e outros do bootcamp) foi possível chegar <br>
ao final da primeira fase do projeto. Adquiri conhecimentos na prática de POO <br>
(Programação Orientada a Objetos) utilizando conceitos de herança, polimorfismo,
encapsulamento e abstração. No caso dos gêneros como possui um certo limite/padrão, foi <br>
utilizando o Enum. Um dos primeiros passos para seguir até o nível JR em .NET 💜 <br>

---

## 🚀 Funcionalidades

- ✅ Listar séries cadastradas  
- ✅ Inserir nova série  
- ✅ Atualizar série existente  
- ✅ Excluir série (soft delete - marca como excluída)  
- ✅ Visualizar detalhes de uma série específica  

---

## 🛠️ Tecnologias Utilizadas

- **.NET 9 / C#**  
- **Paradigma de Programação Orientada a Objetos**  
- **Enums** para representação de gêneros de séries  
- **Coleções genéricas (`List<T>`)** para armazenamento dos dados em memória  

---

## 📚 Conceitos Aplicados

A aplicação foi construída com foco em boas práticas e estudos de arquitetura:

### 🔹 POO (Programação Orientada a Objetos)
- **Encapsulamento**: propriedades privadas com acesso controlado  
- **Abstração**: uso de classes abstratas para entidade base  
- **Herança**: especialização da entidade base para Series  
- **Polimorfismo**: métodos sobrescritos para diferentes comportamentos  

### 🔹 SOLID
- **S**ingle Responsibility Principle: cada classe tem uma responsabilidade clara  
- **O**pen/Closed Principle: código aberto para extensão, mas fechado para modificação  
- **L**iskov Substitution Principle: entidades derivadas podem substituir a base sem problemas  
- **I**nterface Segregation Principle: interfaces especializadas e focadas  
- **D**ependency Inversion Principle: dependências injetadas e abstraídas  

### 🔹 Design Patterns
- **Repository Pattern**: abstração da camada de dados em memória  
- **Factory Method (implícito)**: centralização da criação de objetos em pontos específicos  

---

## 📂 Estrutura do Projeto

DIO.Series/
│-- Application/
│ │-- Services/
│ │ └── SerieAppService.cs
│-- ConsoleUI/
│ └── ConsoleWrapper.cs
│ └── SerieConsoleApp.cs
│-- Domain/
│ │-- Entities/
│ │ └── BaseEntity.cs
│ │ └── Serie.cs
│ │-- Enum/
│ │ └── Genre.cs
│ │ └── MenuOption.cs
│-- Infrastructure/
│ │-- Repository/
│ │ └── SerieRepository.cs
│-- Interfaces/
│ └── IConsole.cs
│ └── ISerieConsole.cs
│ └── ISerieRepository.cs
│-- Program.cs

---

## 🔮 Próximas Melhorias

- [ ] Implementar **testes unitários** (xUnit ou NUnit)  
- [ ] Substituir armazenamento em memória por **persistência em banco de dados**  
- [ ] Criar uma **camada de serviços (Application Service)** para isolar regras de negócio  
- [ ] Implementar **injeção de dependência** nativa do .NET  
- [ ] Criar uma interface gráfica (WinForms, WPF ou Web com ASP.NET Core MVC/Blazor)  

---

## 📌 Observação

Este projeto tem caráter **didático** e foi desenvolvido como parte de estudos da plataforma **Digital Innovation One (DIO)**.  
Não se trata de um produto final, mas de um laboratório para aplicar boas práticas de desenvolvimento de software.

---

### ACESSE: 
[LinkedIn](https://www.linkedin.com/in/hugo-barbosa-a3b40a157/) <br>
[Digital Innovation One](https://web.digitalinnovation.one/users/09silvahugo?tab=achievements) <br>

### LINKEDIN DO PROFESSOR:
[Eliezer Zarpelao](https://www.linkedin.com/in/eliezerzarpelao/)
