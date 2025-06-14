$(document).ready(function () {
    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    $('.delete-offer').click(function () {
        const offerId = $(this).data('id');

        $.ajax({
            url: '/JobOffer/Delete',
            type: 'POST',
            data: { id: offerId },
            headers: {
                'RequestVerificationToken': token
            },
            success: function () {
                $(`button[data-id="${offerId}"]`).closest('tr').fadeOut();
            },
            error: function () {
                alert('Ocurrió un error al eliminar la oferta.');
            }
        });
    });
});

