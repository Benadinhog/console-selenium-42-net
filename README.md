# Console Selenium 42

Projeto desenvolvido para a disciplina de **Garantia da Qualidade de Software**, com o objetivo de implementar testes automatizados utilizando C#, .NET 10, Selenium WebDriver e MSTest.

A aplicação realiza automações de navegação e pesquisa no mecanismo de busca [DuckDuckGo](https://duckduckgo.com), validando diferentes comportamentos por meio de testes automatizados.

## Tecnologias utilizadas

- **C#** — Linguagem de programação.
- **.NET 10** — Plataforma de desenvolvimento.
- **Selenium WebDriver** — Automação de navegadores.
- **Selenium Support** — Recursos de suporte para automação, incluindo esperas explícitas.
- **MSTest** — Framework para execução dos testes automatizados.
- **Google Chrome** — Navegador utilizado nos testes.
- **Visual Studio Code** — Ambiente de desenvolvimento.
- **Git e GitHub** — Controle de versão e hospedagem do projeto.

## Estrutura do projeto

```text
ConsoleSelenium42/
│
├── ConsoleSelenium42.sln
│
├── ConsoleSelenium/
│   ├── ConsoleSelenium.csproj
│   └── Program.cs
│
├── ConsoleSelenium.Tests/
│   ├── ConsoleSelenium.Tests.csproj
│   └── BuscaDesafioTest.cs
│
└── .gitignore
```

## Testes automatizados

O projeto contém três cenários de testes automatizados:

### Exercício 1 — Pesquisa básica e validação de título

**Objetivo:** Automatizar uma pesquisa no DuckDuckGo e validar o carregamento da página de resultados.

Etapas realizadas:
1. Acessar o site DuckDuckGo.
2. Localizar o campo de pesquisa utilizando o atributo `name="q"`.
3. Digitar o termo `Selenium WebDriver C#` utilizando `SendKeys`.
4. Pressionar a tecla Enter.
5. Validar a URL da página de resultados por meio de uma asserção.

### Exercício 2 — Interagindo com o Autocompletar (Suggestions)

**Objetivo:** Interagir com as sugestões dinâmicas apresentadas durante a digitação.

Etapas realizadas:
1. Acessar a página inicial do DuckDuckGo.
2. Digitar o termo `C# unit testing`.
3. Utilizar `WebDriverWait` para aguardar as sugestões.
4. Localizar a terceira opção sugerida.
5. Clicar na opção selecionada.
6. Validar o redirecionamento para os resultados da pesquisa.

### Exercício 3 — Navegação por Histórico e Botões de Ação

**Objetivo:** Automatizar a navegação entre a página de resultados e uma página externa.

Etapas realizadas:
1. Realizar uma pesquisa por `Automated Testing`.
2. Localizar e acessar o primeiro resultado orgânico.
3. Validar o carregamento da página externa verificando a URL atual.
4. Utilizar `Navigation.Back()` para retornar à página anterior.
5. Validar a restauração dos resultados da pesquisa.

## Pré-requisitos

Para executar o projeto, é necessário ter instalado:

- Windows, Linux ou macOS.
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- [Visual Studio Code](https://code.visualstudio.com/).
- [Google Chrome](https://www.google.com/chrome/).

## Como executar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/Benadinhog/console-selenium-42-net.git
```

### 2. Entrar na pasta do projeto

```bash
cd console-selenium-42-net
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Compilar a solução

```bash
dotnet build
```

### 5. Executar os testes automatizados

```bash
dotnet test
```

O comando executará os testes automatizados definidos no projeto `ConsoleSelenium.Tests`.

**Observação:** O Google Chrome deve estar instalado para a execução dos testes. O Selenium Manager auxilia no gerenciamento do ChromeDriver.

## Organização e boas práticas

O projeto foi desenvolvido seguindo algumas práticas de organização e qualidade de código:

- Separação entre aplicação principal e projeto de testes.
- Organização dos cenários em métodos independentes.
- Utilização de asserções para validar os resultados.
- Utilização de esperas explícitas para elementos dinâmicos.
- Encerramento do navegador após cada execução.
- Versionamento utilizando Git.
- Commits seguindo o padrão de mensagens semânticas.

## Autor

**Desenvolvido por:** Bernardo Luiz Monteverde Gonçalves

**Disciplina:** Garantia da Qualidade de Software

**Professor:** Daniel Henrique Matos de Paiva

**Projeto acadêmico:** Lista de Exercícios 42 — Console Selenium .NET 10

---

Desenvolvido como atividade prática de automação de testes de software.
