﻿// ============================================================================================================================= 
// author       : david sexton (@sextondjc | sextondjc.com)
// date         : 2015.12.23 (23:44)
// modified     : 2017-02-19 (22:58)
// licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
// =============================================================================================================================

using System;

namespace Drapper.Commands
{
    /// <summary>
    /// Represents an operation which persists a new object to an underlying store.
    /// </summary>
    public interface ICreateCommand<T> : IDisposable
    {
        /// <summary>
        /// Persists an object to the underlying store.
        /// </summary>
        /// <param name="model">The model. This can be a POCO or primitive type..</param>
        /// <returns></returns>
        T Create(T model);
    }
}
