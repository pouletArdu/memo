namespace Infra;

public class CraService : ICraService
{
    // implemente ICraService using Static list

    private static List<Cra> _craList = [];

    public Cra? Get(int month, int year)
    {
        return _craList.FirstOrDefault(x => x.Month.Month == month && x.Month.Year == year);
    }

    public void Submit(Cra cra)
    {
        cra.Id = _craList.Count;
        _craList.Add(cra);        
    }

    public Cra Update(Cra cra)
    {
        var craToUpdate = _craList.FirstOrDefault(x => x.Id == cra.Id);
        if (craToUpdate == null)
        {
            throw new Exception("Cra not found");
        }
        craToUpdate.Days = cra.Days;
        return craToUpdate;
    }    
}
