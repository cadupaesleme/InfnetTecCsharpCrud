'use strict';

var pedido = (function ($) {

    var init = function () {

        $('.btn-adicionar-item').on('click', adicionarItem);
        $('.btn-salvar-pedido').on('click', salvarPedido);
        $('.item-remover').on('click', removerItem);
        $('.item-produto').on('change', preencherValorUnitario);
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

    var validar = function (pedido) {

        var valido = true;

        $(".field-validation-valid").html('');
        $(".field-validation-valid").addClass('hide');

        if (pedido.CodigoComprador == null) {
            $("#validacaoCliente").html("O campo Cliente é obrigatório");
            $("#validacaoCliente").removeClass("hide");
            valido = false;
        }

        if (pedido.CodigoVendedor == null) {
            $("#validacaoFornecedor").html("O campo Vendedor é obrigatório");
            $("#validacaoFornecedor").removeClass("hide");
            valido = false;
        }

        if (pedido.Itens == null || pedido.Itens.length == 0) {
            $("#validacaoItens").html("O pedido precisa ter pelo menos um item");
            $("#validacaoItens").removeClass("hide");
            valido = false;
        }

        $('.itens .pedido-item').each(function () {

            if ($(this).find('.item-produto').val() == null || $(this).find('.item-produto').val() == "-1") {
                $(this).find(".validacaoItemProduto").html("Favor selecionar o produto deste item");
                $(this).find(".validacaoItemProduto").removeClass("hide");
                valido = false;
            }

            if ((+$(this).find('.item-quantidade').val()) == null || (+$(this).find('.item-quantidade').val()) == 0) {
                $(this).find(".validacaoItemQuantidade").html("A quantidade deste item dever ser maior que zero");
                $(this).find(".validacaoItemQuantidade").removeClass("hide");
                valido = false;
            }

        });

        return valido;
    }

    var salvarPedido = function () {

        var pedido = {
            "CodigoPedido": typeof $("#CodigoPedido").val() === "undefined" ? 0 : $("#CodigoPedido").val(),
            "CodigoComprador": $('#CodigoComprador').val(),
            "CodigoVendedor": $('#CodigoVendedor').val(),
            "Itens": getItens()
        }

        if (validar(pedido) == false)
            return false;

        $.ajax({
            type: 'POST',
            url: "/Pedido/Create/",
            //url: $('.btn-salvar-pedido').data('rota'),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify(pedido),
            error: function (response) {
                alert(response);
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