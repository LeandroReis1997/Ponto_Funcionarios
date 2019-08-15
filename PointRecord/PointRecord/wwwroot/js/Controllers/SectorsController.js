class SectorsController {
    StartSector() {
        $(".btnRemover").on("click", function () {
            var id = $(this).attr("id");
            let url = "/sectors/delete/" + id;
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
                text: `Deseja apagar o setor ${name} ?`,
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
                        `O setor ${name} foi removido`,
                        'success')

                    $.ajax({
                        type: 'POST',
                        url: url

                    }).fail((error) => {
                        let msg = $("#msg");
                        msg.text("Não possível completar a operação");
                        msg.show();
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