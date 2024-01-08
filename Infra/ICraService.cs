using Infra.Entities;

namespace Infra;

public interface ICraService
{
    public Cra? Get(int month, int year);
    public Cra Update(Cra cra);
    public void Submit(Cra cra);
}
