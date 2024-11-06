$(document).ready(function () {


    $('#add-btn').on('click', function () {
       
        $.ajax({
            type: 'GET',
            url: '/Students/Add',
            contentType: "application/json",
            success: function (addForm) {
                console.log(addForm);

                $('#add-form').empty().append(addForm);
                document.getElementById('add-form').style.display = "block";

            },
            error: function (xhr, status, error) {
                alert('An error occurred while saving the student. Please try again.');
            }
        });
    });

    $(document).on('submit', '#addStudentForm', function (event) {
        event.preventDefault();

        //$('.error-message').remove();

        
        //let isValid = true;

        
        //const name = $("#Name").val().trim();
        //const email = $("#Email").val().trim();
        //const phone = $("#Phone").val().trim();
        //const percentage = $("#Percentage").val().trim();

        
        //if (!name) {
        //    isValid = false;
        //    $("#Name").after('<span class="error-message" style="color:red;">Please enter your name.</span>');
        //}

        
        //const emailPattern = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
        //if (!email || !emailPattern.test(email)) {
        //    isValid = false;
        //    $("#Email").after('<span class="error-message" style="color:red;">Please enter a valid email.</span>');
        //}

        
        //const phonePattern = /^\d{10}$/;
        //if (phone != undefined && phonePattern.test(phone) == false) {
        //    isValid = false;
        //    $("#Phone").after('<span class="error-message" style="color:red;">Phone number must be 10 digits.</span>');
        //}
        //else if (phone == null || phone == undefined) {
        //    $("#Phone").after('<span class="error-message" style="color:red;">Please enter Phone Number!</span>');

        //}

        
        //const percentageNum = parseInt(percentage, 10);
        //if (!percentage || percentageNum < 1 || percentageNum > 100) {
        //    isValid = false;
        //    $("#Percentage").after('<span class="error-message" style="color:red;">Percentage must be between 1 and 100.</span>');
        //}

        
        //if (!isValid) {
        //    return;
        //}


        var formData = {
            Id: $("#Id").val(),
            Name: $("#Name").val(),
            Email: $("#Email").val(),
            Phone: $("#Phone").val(),
            Percentage: $("#Percentage").val()
        };

        $.ajax({
            type: 'POST',
            url: '/Students/Create',
            data: JSON.stringify(formData),
            contentType: "application/json",
            
            success: function (students) {
                console.log(students);

                $('#st-table tbody').empty();
                students.forEach(function (student) {
                    $('#st-table tbody').append(`
                                <tr id="student-${student.id}">
                                    <td>${student.id}</td>
                                    <td>${student.name}</td>
                                    <td>${student.email}</td>
                                    <td>${student.phone}</td>
                                    <td>${student.percentage}</td>
                                   <td>
                                    <a class="btn btn-primary edit-button" href="#"
                                    data-id="${student.id}"
                                    data-name="${student.name}"
                                    data-email="${student.email}"
                                    data-phone="${student.phone}"
                                    data-percentage="${student.percentage}"
                                    data-bs-toggle="modal"
                                    data-bs-target="#editModal">Edit</a>

                                  <form action="/Students/Delete" method="post" style="display:inline;" onsubmit="return confirmDelete(event, this);">
                                  <input type="hidden" name="id" value="${student.id}" />
                                  <button type="submit" class="btn btn-danger ms-3">Delete</button>
                                  </form>

                                   <button id="promote" type="button" class="btn btn-success ms-3" data-id="${student.id}">Promote</button>
                                 </td>


                                </tr>
                            `);
                });
                document.getElementById('add-form').style.display = "none";

            },
            error: function (xhr, status, error) {
                document.getElementById('save-msg').style.display = "block";
                $('#save-msg').empty().append(xhr.responseText.toString());
            }
        });
    });
})