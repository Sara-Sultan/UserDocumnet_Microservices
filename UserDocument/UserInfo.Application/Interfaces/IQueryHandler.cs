using System;
using System.Collections.Generic;
using System.Text;


namespace Document.Application.Interfaces
{
    public interface IQuery
    {
    }
    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<T> : IQueryHandler where T : IQuery
    {
        IList<IResult> Handle(T query);
        
    }

}
