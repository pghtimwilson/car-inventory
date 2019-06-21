import * as React from 'react';

export function useInventory() {
    const [inventory, setInventory] = React.useState([]);

    React.useEffect(() => {
        var requestHeaders = new Headers();
        requestHeaders.append('Accept', 'application/json');
        requestHeaders.append('Content-Type', 'application/json');

        var requestObject = {
            method: 'Get',
            headers: requestHeaders,
        };

        fetch('https://localhost:44320/api/inventory', requestObject)
            .then((results) => results.json())
            .then((data) => {
                const mappedInventory = JSON.parse(data).map((item) => ({
                    type: item.VehicleType,
                    make: item.Make,
                    model: item.Model,
                    retailPrice: item.RetailPrice,
                }));

                setInventory(mappedInventory);
            });
    }, []);

    return inventory;
}