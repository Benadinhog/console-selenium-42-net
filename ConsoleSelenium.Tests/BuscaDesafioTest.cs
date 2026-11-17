using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleSelenium.Tests
{
    [TestClass]
    public class BuscaDesafioTest
    {
        [TestMethod]
        public void Exercicio1_PesquisaBasicaDuckDuckGo()
        {
            // 1. Inicializar o navegador Chrome
            IWebDriver driver = new ChromeDriver();

            try
            {
                // 2. Acessar o DuckDuckGo
                driver.Navigate().GoToUrl("https://duckduckgo.com");

                // 3. Localizar o campo de pesquisa
                IWebElement campoPesquisa =
                    driver.FindElement(By.Name("q"));

                // 4. Digitar o termo pesquisado
                campoPesquisa.SendKeys("Selenium WebDriver C#");

                // 5. Pressionar Enter
                campoPesquisa.SendKeys(Keys.Enter);

                // 6. Aguardar o carregamento dos resultados
                WebDriverWait espera = new WebDriverWait(
                    driver,
                    TimeSpan.FromSeconds(15)
                );

                espera.Until(d => d.Url.Contains("q="));

                // 7. Validar a URL dos resultados
                string urlAtual = Uri.UnescapeDataString(
                    driver.Url.Replace("+", " ")
                );

                Assert.IsTrue(
                    urlAtual.Contains(
                        "Selenium WebDriver C#",
                        StringComparison.OrdinalIgnoreCase
                    ),
                    "A pesquisa não foi realizada corretamente."
                );
            }
            finally
            {
                // 8. Fechar o navegador
                driver.Quit();
            }
        }

         [TestMethod]
        public void Exercicio2_AutocompletarDuckDuckGo()
        {
            // 1. Inicializar o navegador Chrome
            IWebDriver driver = new ChromeDriver();

            try
            {
                // 2. Acessar o DuckDuckGo
                driver.Navigate().GoToUrl("https://duckduckgo.com");

                // 3. Localizar o campo de pesquisa
                IWebElement campoPesquisa =
                    driver.FindElement(By.Name("q"));

                // 4. Digitar o termo sem pressionar Enter
                campoPesquisa.SendKeys("C# unit testing");

                // 5. Criar uma espera explícita
                WebDriverWait espera = new WebDriverWait(
                    driver,
                    TimeSpan.FromSeconds(15)
                );

                // 6. Aguardar pelo menos três sugestões visíveis
                var sugestoes = espera.Until(d =>
                {
                    var opcoes = d.FindElements(
                        By.CssSelector(
                            ".search-suggestions-list li, " +
                            ".sbox-suggestions li, " +
                            "[role='option']"
                        )
                    )
                    .Where(elemento => elemento.Displayed)
                    .ToList();

                    return opcoes.Count >= 3 ? opcoes : null;
                });

                // 7. Capturar o texto da terceira sugestão
                string terceiraOpcao = sugestoes[2].Text;

                // 8. Clicar na terceira sugestão
                sugestoes[2].Click();

                // 9. Aguardar o redirecionamento
                espera.Until(d =>
                    d.Url.Contains(
                        "q=",
                        StringComparison.OrdinalIgnoreCase
                    )
                );

                // 10. Validar o redirecionamento
                Assert.IsTrue(
                    driver.Url.Contains("q="),
                    "O redirecionamento não ocorreu corretamente."
                );

                Assert.IsFalse(
                    string.IsNullOrWhiteSpace(terceiraOpcao),
                    "A terceira sugestão não possui texto."
                );
            }
            finally
            {
                // 11. Fechar o navegador
                driver.Quit();
            }
        }


        [TestMethod]
        public void Exercicio3_NavegacaoHistoricoDuckDuckGo()
        {
            // 1. Inicializar o navegador Chrome
            IWebDriver driver = new ChromeDriver();

            try
            {
                // 2. Acessar o DuckDuckGo
                driver.Navigate().GoToUrl("https://duckduckgo.com");

                // 3. Localizar o campo de pesquisa
                IWebElement campoPesquisa =
                    driver.FindElement(By.Name("q"));

                // 4. Realizar a pesquisa
                campoPesquisa.SendKeys("Automated Testing");
                campoPesquisa.SendKeys(Keys.Enter);

                // 5. Criar espera explícita
                WebDriverWait espera = new WebDriverWait(
                    driver,
                    TimeSpan.FromSeconds(20)
                );

                // 6. Aguardar os resultados aparecerem
                var primeiroResultado = espera.Until(d =>
                {
                    var links = d.FindElements(
                        By.CssSelector(
                            "a[data-testid='result-title-a']"
                        )
                    );

                    return links.FirstOrDefault(
                        link => link.Displayed &&
                        !string.IsNullOrWhiteSpace(link.Text)
                    );
                });

                // 7. Guardar a URL da pesquisa
                string urlResultados = driver.Url;

                // 8. Clicar no primeiro resultado orgânico
                primeiroResultado.Click();

                // 9. Aguardar o carregamento da página externa
                espera.Until(d =>
                {
                    Uri urlAtual = new Uri(d.Url);

                    return !urlAtual.Host.Contains(
                        "duckduckgo.com",
                        StringComparison.OrdinalIgnoreCase
                    );
                });

                // 10. Validar que acessamos uma página externa
                string urlExterna = driver.Url;

                Assert.IsTrue(
                    !urlExterna.Contains(
                        "duckduckgo.com",
                        StringComparison.OrdinalIgnoreCase
                    ),
                    "A página externa não foi carregada."
                );

                // 11. Voltar para a página anterior
                driver.Navigate().Back();

                // 12. Aguardar o retorno aos resultados
                espera.Until(d =>
                    d.Url == urlResultados
                );

                // 13. Validar que os resultados foram restaurados
                var resultadosRestaurados =
                    driver.FindElements(
                        By.CssSelector(
                            "a[data-testid='result-title-a']"
                        )
                    );

                Assert.IsTrue(
                    resultadosRestaurados.Any(
                        link => link.Displayed
                    ),
                    "Os resultados da pesquisa não foram restaurados."
                );
            }
            finally
            {
                // 14. Fechar o navegador
                driver.Quit();
            }
        }
    }
}