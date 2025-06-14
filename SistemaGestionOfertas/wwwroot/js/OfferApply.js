document.addEventListener("DOMContentLoaded", function () {
    const modal = new bootstrap.Modal(document.getElementById("applyModal"));
    const applyForm = document.getElementById("applyForm");
    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    document.querySelectorAll(".apply-offer").forEach(button => {
        button.addEventListener("click", () => {
            modal.show();
        });
    });

    applyForm.addEventListener("submit", function (e) {
        e.preventDefault();

        fetch("/JobOffer/Apply", {
            method: "POST",
            headers: {
                "RequestVerificationToken": token
            }
        })
            .then(response => {
                if (response.ok) {
                    modal.hide();
                    alert("Postulaci�n enviado correctamente.");
                } else {
                    alert("Error al enviar postualci�n.");
                }
            })
            .catch(error => {
                console.error(error);
                alert("Error inesperado.");
            });
    });
});

