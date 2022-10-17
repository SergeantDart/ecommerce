using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluation<E> where E : BaseEntity
    {
        public static IQueryable<E> GetQuery(IQueryable<E> inputQuery, ISpecification<E> spec) {
            var query = inputQuery;
            if (spec.Criteria != null) {
                query = query.Where(spec.Criteria);
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}