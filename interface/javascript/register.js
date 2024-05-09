// function signup(event) {
//     event.preventDefault();
//     window.location.href = "index.html";
// }

// Function to handle user signup
async function signupUser(username, email, password, confirmPassword) {
    try {
        const response = await fetch('https://localhost:7156/api/Account/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username, email, password, confirmPassword })
        });

        const data = await response.json();

        if (!response.ok) {
            throw new Error(data.message || 'Unable to sign up');
        }

        return data.token; // Assuming your server returns the JWT token in the response
    } catch (error) {
        console.error('Signup failed:', error);
        throw error;
    }
}

// Or for signup
signupUser('newUser', 'email', 'newPassword', 'confirmNewPassword')
    .then(token => {
        console.log('Signed up. Token:', token);
        // Store the token in localStorage or sessionStorage for subsequent requests
    })
    .catch(error => {
        console.error('Signup failed:', error);
    });

signupUser('basem', 'basembaraka84521@gmail.com', 'Basem214*', 'Basem214*')
