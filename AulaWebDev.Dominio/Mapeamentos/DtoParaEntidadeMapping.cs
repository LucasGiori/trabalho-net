﻿using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Entidades;
using AutoMapper;

namespace AulaWebDev.Dominio.Mapeamentos
{
    public class DtoParaEntidadeMapping : Profile
    {
        public DtoParaEntidadeMapping()
        {
            CreateMap<ClienteDto, Cliente>();
            CreateMap<ProdutoResponseDto, Produto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<PedidoResponseDto, Pedido>();
        }
    }
}
