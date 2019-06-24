import * as React from 'react';
import { useInventory } from './hooks/useInventory';

export default function TotalSellingPrice(){
    var inventory = useInventory(false);

    var total = 0;
    if(inventory && inventory.length > 0)
    {
        inventory.forEach((item) => {
            total += item.calculatedSalesPrice;
        });
    }

    return (
        <div>
            <h3>Total Selling Price {total.toLocaleString('en-US', { style: 'currency', currency: 'USD' })}</h3>
        </div>
    );
}