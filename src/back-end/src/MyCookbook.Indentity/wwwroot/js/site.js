class Password {
    showPasswordClick(inputClass) {
        let showPasswordInput = $(`.${inputClass} input`);
        let showPasswordButton = $(`.${inputClass} button`);
        let showPasswordIcon = $(`.${inputClass} i`);

        showPasswordButton.on('click', function (event) {
            event.preventDefault();

            if (showPasswordInput.attr("type") == "text") {
                showPasswordInput.attr("type", "password");

                showPasswordIcon
                    .addClass("bi bi-eye-slash")
                    .removeClass("bi bi-eye");
            }
            else if (showPasswordInput.attr("type") == "password") {
                showPasswordInput.attr("type", "text");

                showPasswordIcon
                    .removeClass("bi bi-eye-slash")
                    .addClass("bi bi-eye");
            }
        });
    }
}
