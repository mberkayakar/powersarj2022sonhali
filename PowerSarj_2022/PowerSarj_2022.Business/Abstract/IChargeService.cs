namespace PowerSarj_2022.Business.Abstract
{
    public interface IChargeService
    {
        string INFO(string deviceid, string state, string charginguser, string cardid );
        string MOBILCHECK(string deviceid, string state, string charginguser, string cardid);
        string START(string deviceid, string state, string charginguser, string cardid);
        string STOP(string deviceid, string state, string charginguser, string cardid);


    }
}
