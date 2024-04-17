$(document).ready(function () {

    if (document.getElementById("gridBeneficiarios")) {
        $('#gridBeneficiarios').jtable({
            title: 'Beneficiarios',
            paging: true, 
            pageSize: 5, 
            sorting: true, 
            defaultSorting: 'Nome ASC',
            actions: {
                listAction: urlBeneficiarioList,
            },
            fields: {
                Email: {
                    title: 'CPF',
                    width: '40%'
                },
                Nome: {
                    title: 'Nome',
                    width: '40%'
                },
                Alterar: {
                    title: '',
                    display: function (data) {
                        return '<button onclick="window.location.href=\'' + urlAlteracao + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>';
                    }
                },
                 Excluir: {
                     title: '',
                     display: function (data) {
                         return '<button onclick="window.location.href=\'' + urlExclusao + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>';
                     }
                 }
            }
        });

        $('#gridBeneficiarios').jtable('load');
    }
});