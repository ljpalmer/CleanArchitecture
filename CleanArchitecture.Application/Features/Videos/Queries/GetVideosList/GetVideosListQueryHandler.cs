using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository _videosRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videosRepository, IMapper mapper)
        {
            _videosRepository = videosRepository;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videosRepository.GetVideoByUsername(request._username);
            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
