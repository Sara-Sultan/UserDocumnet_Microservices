using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Application.Interfaces
{
    public interface IResult
    {
    }

    public interface IListResult : ICollection<IResult>
    {
    }
}
