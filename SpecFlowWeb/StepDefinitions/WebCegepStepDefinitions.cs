using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using NUnit;
using NUnit.Framework;

namespace SpecFlowWeb.StepDefinitions
{
    [Binding]
    public class WebCegepStepDefinitions
    {
        private string _adresse;
        private string _mot;

        private WebDriver _webDriver;


        [Given(@"L'adresse du site web est (.*)")]
        public void GivenLadresseDuSiteWebEst(string adresse)
        {
            _adresse=adresse;
        }

        [When(@"J'ouvre la page")]
        public void WhenJouvreLaPage()
        {
            _webDriver.Url = _adresse;
            _webDriver.Navigate();
        }

        [Then(@"le titre devrait contenir (.*)")]
        public void ThenLeTitreDevraitContenir(string mot)
        {
            _mot = mot;
            Assert.IsTrue(_webDriver.Title.Contains(mot));
            
        }

        [Before()]
        public void Before()
        {
            _webDriver = new EdgeDriver(@"C:\@cegepsth.qc.ca\3DG");
        }

        [After()]
        public void After()
        {
            _webDriver.Quit();
        }


        [When(@"Je clique sur le lien contenant le texte (.*)")]
        public void WhenJeCliqueSurLeLien(string texte)
        {
            string xpath = @"//a[contains(.,'" + texte + "')]";
            var element = _webDriver.FindElement(By.XPath(xpath));
            element.Click();
        }

        [When(@"Je passe à l'onglet (.*)")]
        public void WhenJePasseALonglet(int fenetre)
        {
            _webDriver.SwitchTo()
                .Window(_webDriver.WindowHandles[fenetre]);
        }

    }
}
