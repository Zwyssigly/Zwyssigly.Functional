﻿using System.Collections.Generic;
using System.Linq;

namespace Zwyssigly.Functional
{
    public static class ResultEnumerableExtensions
    {
        public static IEnumerable<TSuccess> SelectSuccess<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> self)
        {
            return self.Where(r => r.IsSuccess).Select(r => r.UnwrapOrThrow());
        }

        public static IEnumerable<TFailure> SelectFailure<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> self)
        {
            return self.Where(r => r.IsFailure).Select(r => r.Failure.UnwrapOrThrow());
        }
    }
}
