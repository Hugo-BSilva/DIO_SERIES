using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    //Substitui o T pela Serie da classe SerieRepositorio.cs
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}