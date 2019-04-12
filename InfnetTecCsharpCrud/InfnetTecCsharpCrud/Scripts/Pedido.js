'use strict';

var pedido = (function ($) {

    var init = function () {

        $('.btn-adicionar-item').on('click', adicionarItem);
        $('.btn-salvar-pedido').on('click', salvarPedido);

    };

    var adicionarItem = function () {
        $('.itens').append($('.modelo').html());
        $('.item-remover').on('click', removerItem);
        $('.item-produto').on('change', preencherValorUnitario);
    }

    var removerItem = function () {
        $(this).closest('.pedido-item').remove();
    }

    var preencherValorUnitario = function () {
        $(this).closest('.pedido-item').find('.item-valor-unitario').html($("option:selected", this).data('preco'));
    }

    var getItens = function () {

        var itens = [];

        $('.itens .pedido-item').each(function () {

            itens.push({

                'CodigoProduto': $(this).find('.item-produto').val(),
                'Qtd': $(this).find('.item-quantidade').val(),
                'ValorUnitario': $(this).find('.item-valor-unitario').html()
            })

        });

        return itens;
    }

    var salvarPedido = function () {

        var pedido = {

            "CodigoComprador": $('#CodigoComprador').val(),
            "CodigoVendedor": $('#CodigoVendedor').val(),
            "Itens": getItens()
        }


        $.ajax({
            type: 'POST',
            url: "/Pedido/Create/",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify(pedido),
            error: function (response) {
                alert(response.responseText);
            },
            success: function (response) {
                window.location = "/Pedido/Index/";
            }
        });
    }

    return {
        init: init
    };

})(jQuery);

document.addEventListener("DOMContentLoaded", pedido.init);