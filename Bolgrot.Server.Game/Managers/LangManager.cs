using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Network;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using ServiceStack;

namespace Bolgrot.Server.Game.Managers
{
    public interface ILangManager
    {
        public string GetLang(int word, string lang);
    }
    public class LangManager : AbstractGameManager, ILangManager
    {
        public Dictionary<int, string[]> Words { get; set; }
        public LangManager()
        {

        }
        public string GetLang(int word, string lang)
        {
            int lang_temp = 0;
            switch (lang)
            {
                case "fr":
                    lang_temp = 1;
                    break;
                case "es":
                    lang_temp = 2;
                    break;
                case "pt":
                    lang_temp = 3;
                    break;
                default:
                    lang_temp = 0;
                    break;
            }
            return this.Words[word][lang_temp];
        }
        public void Initialize()
        {
            //this.Words = new Dictionary<int, string[]>();
            // en/fr/es/pt
            this.Words = new Dictionary<int, string[]>{
                { 0, new string[]{"","","","" } },
                { 1, new string[]{"Saiki", "Saiki", "Saiki", "Saiki" } },
                { 2, new string[]{ "Bienvenue sur <b>Bolgrot</b>, serveur en version BETA développé par Ten !", "Bienvenue sur <b>Bolgrot</b>, serveur en version BETA développé par Ten !", "Bienvenue sur <b>Bolgrot</b>, serveur en version BETA développé par Ten !", "Bem-vindo ao <b>Bolgrot</b>, servidor em versão BETA desenvolvido por Ten !" } },
            };
            //todo
        }
        
    }
}