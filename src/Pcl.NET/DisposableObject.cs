﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
  /*
   https://github.com/jbruening/PclSharp
   */
  public abstract class DisposableObject : IDisposable
  {
    protected bool _suppressDispose;

    private int _disposed;

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    ~DisposableObject()
    {
      Dispose(disposing: false);
    }

    private void Dispose(bool disposing)
    {
      if (Interlocked.Exchange(ref _disposed, 1) == 0)
      {
        if (disposing)
        {
          RelaseManagedResources();
        }
        if (!_suppressDispose)
        {
          DisposeObject();
        }
      }
    }

    protected virtual void RelaseManagedResources()
    {
    }

    protected abstract void DisposeObject();
  }
}
