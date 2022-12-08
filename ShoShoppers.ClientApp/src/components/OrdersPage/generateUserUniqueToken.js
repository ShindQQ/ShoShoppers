export async function generateUserUniqueToken() {
    const response = await fetch('/api/Order/GenerateUserUniqueToken', {
        method: 'GET',
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    });

    let userToken = await response.json();

    localStorage.setItem("UserToken", userToken);

    return userToken;
}