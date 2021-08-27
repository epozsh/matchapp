using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchAPP.Domain.Services
{
    public abstract class RepositoryService
    {
        public readonly IMapper _mapper;
        public readonly IMemoryCache _memoryCache;

        public int defaultSlideExpirationInMinutes = 60; // 1 hour

        public RepositoryService(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
    }
}
