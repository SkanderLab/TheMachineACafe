using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TheMachineACafe
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IGetADrink" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IGetADrink
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{value}")]
        Drink GetMeADrink(int UserID, DrinkType requestedDrinkType, SugarLevel _requestedSugarLevel, bool havingACup);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{value}")]
        Drink GetMyFavouriteDrink(int UserID);
    }

    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    [Serializable()]
    public class Drink
    {
        bool _withNoCup = false;
        DrinkType _drinkType = DrinkType.None;
        SugarLevel _sugarLevel = SugarLevel.None;

        public Drink(DrinkType requestedDrinkType, SugarLevel _requestedSugarLevel, bool havingACup)
        {
            _drinkType = requestedDrinkType;
            _sugarLevel = _requestedSugarLevel;
            _withNoCup = havingACup;
        }

        [DataMember]
        public bool WithNoCup
        {
            get { return _withNoCup; }
            set { _withNoCup = value; }
        }

        [DataMember]
        public DrinkType MyDrinkType
        {
            get { return _drinkType; }
            set { _drinkType = value; }
        }

        [DataMember]
        public SugarLevel MySugarLevel
        {
            get { return _sugarLevel; }
            set { _sugarLevel = value; }
        }
    }

    public enum DrinkType
    {
        None        = 0,
        COFFEE      = 1,
        TEA         = 2,
        CHOCOLATE   = 3
    }

    public enum SugarLevel
    {
        None = 0,
        LITTLE = 1,
        MEDUIM = 2,
        HIGHT = 3
    }
}
