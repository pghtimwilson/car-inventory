import * as React from 'react';
import { useInventory } from './hooks/useInventory';

export default function TotalPotentialProfit(props) {
    var inventory = useInventory(props.notifier);

    var total = 0;
    if(inventory && inventory.length > 0)
    {
        inventory.forEach((item) => {
            total += item.retailPrice * (item.markup/100);
        });
    }

    return (
        <div>
            <h3>Total Potential Profit {total.toLocaleString('en-US', { style: 'currency', currency: 'USD' })}</h3>
        </div>
    );
}