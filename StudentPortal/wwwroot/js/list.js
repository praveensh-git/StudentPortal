$(document).ready(function () {

   
    $(document).on('click', '.edit-button', function () {
        const studentId = $(this).data('id');
        const studentName = $(this).data('name');
        const studentEmail = $(this).data('email');
        const studentPhone = $(this).data('phone');
        const studentPercentage = $(this).data('percentage');

        $('#studentId').val(studentId);
        $('#studentName').val(studentName);
        $('#studentEmail').val(studentEmail);
        $('#studentPhone').val(studentPhone);
        $('#studentPercentage').val(studentPercentage);
    });

    $(document).on('click', '#saveChanges', function (event) {
        event.preventDefault();

        const studentData = {
            Id: $('#studentId').val(),
            Name: $('#studentName').val(),
            Email: $('#studentEmail').val(),
            Phone: $('#studentPhone').val(),
            Percentage: $('#studentPercentage').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Students/UpdateStudent',
            contentType: 'application/json',
            data: JSON.stringify(studentData),
            success: function (response) {
                if (response.success) {
                    const studentRow = $('#student-' + studentData.Id);
                    studentRow.find('td:eq(1)').text(studentData.Name);
                    studentRow.find('td:eq(2)').text(studentData.Email);
                    studentRow.find('td:eq(3)').text(studentData.Phone);
                    studentRow.find('td:eq(4)').text(studentData.Percentage);

                    $('#editModal').modal('hide');
                } else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, error) {
                console.error('AJAX Error:', error);
                alert('An error occurred while updating the student. Please try again.');
            }
        });
    });

    $('#st-tbl-body').on('click', '#promote', function () {
        
        const row = $(this).closest('tr');

        
        const studentId = row.attr('id').split('-')[1];
        const name = row.find('td:eq(1)').text(); 
        const email = row.find('td:eq(2)').text(); 
        const phone = row.find('td:eq(3)').text();
        const percentage = row.find('td:eq(4)').text();

        
        const dataToSend = {
            Id: parseInt(studentId, 10),
            Name: name,
            Email: email,
            Phone: phone,
            Percentage: parseFloat(percentage) 
        };

        if (dataToSend.Percentage <= 60) {
            alert("You are not Eligible")
            return;
        }

        
        $.ajax({
            url: '/Students/TransferStudent', 
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dataToSend),
            success: function (students) {

                alert('Student promoted successfully!');
                $('#st-table tbody').empty();
                students.forEach(function (student) {
                    $('#st-table tbody').append(`
                            <tr id="student-${student.id}">
                                <td>${student.id}</td>
                                <td>${student.name}</td>
                                <td>${student.email}</td>
                                <td>${student.phone}</td>
                                <td>${student.percentage}</td>
                                
                            </tr>
                        `);
                })
                window.location.assign('Students/ListStudent11');
            },
            error: function (xhr, status, error) {
                
                alert('An error occurred: ' + error);
            }
        });
    });

});


function confirmDelete(event, form) {
    event.preventDefault();
    const isConfirmed = confirm("Are you sure you want to delete this student?");
    if (isConfirmed) {
        form.submit();
    } else {
        console.log("Deletion cancelled.");
    }
}


