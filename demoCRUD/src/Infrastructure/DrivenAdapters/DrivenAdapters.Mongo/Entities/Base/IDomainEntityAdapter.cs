namespace DrivenAdapters.Mongo.Entities.Base;

public interface IDomainEntityAdapter<out T> where T : class
{
    public T AsEntity();
}