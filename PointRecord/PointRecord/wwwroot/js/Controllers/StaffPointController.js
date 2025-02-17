﻿class StaffPointController {
    StartStaffPoint() {
        $(".btnRemover").on("click", function () {
            var id = $(this).attr("id");
            let url = `/staffpoint/delete/${id}`;
            var name = $(this).attr("name");
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: true
            })

            swalWithBootstrapButtons.fire({
                title: 'Você tem certeza?',
                text: `Deseja apagar o ponto ${id} ?`,
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sim, Confirmar',
                cancelButtonText: 'Não, Cancelar',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    setTimeout(() => {
                        $(this).parent().parent().parent().fadeOut();
                    }, 800);
                    setTimeout(() => {
                        msg.hide();
                    }, 5000);
                    swalWithBootstrapButtons.fire(
                        'Deletado!',
                        `O ponto ${name} foi removido!`,
                        'success')
                    toastr.success("Registro de ponto excluído com sucesso!");

                    $.ajax({
                        type: 'POST',
                        url: url

                    }).fail((error) => {
                        toastr.error("Falha na operação!")
                        setTimeout(() => {
                            msg.hide();
                        }, 5000);
                    });
                } else if (
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'Cancelado',
                        'Exclusão abortada!',
                        'error'
                    )
                }
            })
        });
    }
}