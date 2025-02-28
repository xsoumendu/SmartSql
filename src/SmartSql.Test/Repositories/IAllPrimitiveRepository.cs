﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SmartSql.AOP;
using SmartSql.DyRepository.Annotations;
using SmartSql.Test.Entities;

namespace SmartSql.Test.Repositories
{
    public interface IAllPrimitiveRepository
    {
        [Statement(Id = "QueryByTaken", Sql = "SELECT T.* From T_AllPrimitive T limit ?Taken")]
        IList<AllPrimitive> Query([Param("Taken")] int taken);

        long Insert(AllPrimitive entity);

        (IList<AllPrimitive>, int) GetByPage_ValueTuple(int PageSize = 10, int Offset = 1);

        [UseTransaction]
        [Statement(Id = "Insert")]
        long InsertByAnnotationTransaction(AllPrimitive entity);

        [Transaction]
        [Statement(Id = "Insert")]
        long InsertByAnnotationAOPTransaction(AllPrimitive entity);

        [Statement(Id = "QueryDictionary", Sql = "SELECT T.* From T_AllPrimitive T limit ?Taken")]
        IList<IDictionary<String, Object>> QueryDictionary([Param("Taken")] int taken);
    }
}