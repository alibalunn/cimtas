const sendRequest = async (URL, METHOD_TYPE, BODY) => {
    const options = {
        method: METHOD_TYPE,
        headers: {
            'Content-Type': 'application/json'
        }
    };
    if (BODY) {
        options.body = JSON.stringify(BODY);
    }

    try {
        const response = await fetch(URL, options);

        if (!response.ok) {
            throw new Error('API hatası: ' + response.status);
        }

        const data = await response.json();
        return data;
    } catch (error) {
        console.error('İstek hatası:', error);
        throw error;
    }
};