// function login(event) {
//     event.preventDefault();
//     window.location.href = "index.html";
// }

// Function to handle user login
async function loginUser(username, password) {
    try {
        const response = await fetch('https://localhost:7156/api/Account/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username, password })
        });

        const data = await response.json();

        if (!response.ok) {
            throw new Error(data.message || 'Unable to login');
        }

        return data.token; // Assuming your server returns the JWT token in the response
    } catch (error) {
        console.error('Login failed:', error);
        throw error;
    }
}

// Example usage:
loginUser('exampleUser', 'examplePassword')
    .then(token => {
        console.log('Logged in. Token:', token);
        // Store the token in localStorage or sessionStorage for subsequent requests
    })
    .catch(error => {
        console.error('Login failed:', error);
    });

loginUser('basem', 'Basem214*')
