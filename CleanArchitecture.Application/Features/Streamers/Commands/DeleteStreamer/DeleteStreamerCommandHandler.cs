﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Infraestructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger; //Trabajar sobre el objeto inyectado

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);
            if (streamerToDelete == null)
            {
                _logger.LogError($"{request.Id} streamer no existe en el sistema");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }
            await _streamerRepository.DeleteAsync(streamerToDelete);
            _logger.LogInformation($"El {request.Id} streamer fue eliminado con exito");

            return Unit.Value;
        }
    }
}
