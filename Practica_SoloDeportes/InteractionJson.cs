using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Practica_SoloDeportes.Controllers;

namespace Practica_SoloDeportes
{
    public class InteractionJson
    {
        //var json = File.ReadAllText(@"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json");
        //solo tendra 4 metodos o 5 para modificar los json
        //actualizar ,eliminar , get all , get by id , update ,deleted, create 
        public List<InicializacionTradeMark> get()
        {
            var json = File.ReadAllText(@"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json");
            try
            {
                var obj = JObject.Parse(json);
                var result = obj["TradeMark"].ToObject<List<InicializacionTradeMark>>();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<InicializacionTradeMark> UpdateTM()
        {
            var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json";
            var json = File.ReadAllText(jsonfile);
            try

            {


                var Up = JObject.Parse(json);
                JArray ArrayJson = (JArray)Up["TradeMark"];
                var TMID = 77;
                if (TMID >= 0)
                {
                    var TMName = "Rebook";
                    foreach (var update in ArrayJson.Where(obj => obj["id"].Value<int>() == TMID))
                    {
                        update["description"] = !string.IsNullOrEmpty(TMName) ? TMName : "";
                    }
                    Up["TradeMark"] = ArrayJson;
                    String output = Newtonsoft.Json.JsonConvert.SerializeObject(Up, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonfile, output);
                    //var result = Up["TradeMark"].ToObject<List<InicializacionTradeMark>>();
                    return null;

                }
                else
                {
                    Console.Write("Invalid code");
                    return UpdateTM();
                }
            }

            catch (Exception)
            {

                throw;
            }
        }


        public List<InicializacionTradeMark> DeleteTM()
        {
            var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json";
            var json = File.ReadAllText(jsonfile);
            try
            {
                var DeleteTM = JObject.Parse(json);
                JArray ArrayJSon = (JArray)DeleteTM["TradeMark"];
                var TMID = 17;
                if (TMID > 0)
                {
                    var TMDes = string.Empty;
                    var TMDE = ArrayJSon.FirstOrDefault(obj => obj["id"].Value<int>() == TMID);
                    ArrayJSon.Remove(TMDE);
                    String output = Newtonsoft.Json.JsonConvert.SerializeObject(DeleteTM, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonfile, output);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }


        public List<InicializacionTradeMark> AddTM()
        {

            Console.WriteLine("Enter ID of the new Trademark: ");
            var newTMID = Console.ReadLine();

            Console.WriteLine("Enter Company Name : ");
            var newTMName = Console.ReadLine();

            var Adddata = new Postdata();
            {
            }



            //$@"[{{'Key':'{ abc}','Value': {pqr} }}]"
            //"{\"id\":\"\ newTMID "}"
            //interpobracion 
            //        ,
            //{
            //            "id": 7,
            //  "description": "Converse"
            //}

            try
            {

                var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json";
        var json = File.ReadAllText(jsonfile);

        var jsonadd = JObject.Parse(json);
        var AddArray = jsonadd.GetValue("TradeMark") as JArray;
        var NewTM = JObject.Parse(NewTradeMark);
        AddArray.Add(NewTM);

                jsonadd["TradeMark"] = AddArray;
                string jsonaddednew = Newtonsoft.Json.JsonConvert.SerializeObject(jsonadd, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(jsonfile, jsonaddednew);
            }
            catch (Exception)
            {

                throw;
            }
return null;
        }
    }

}
