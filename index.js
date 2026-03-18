const goldPrices = [
    { date: "2026-03-18", price: 100 },
    { date: "2026-03-17", price: 200 },
    { date: "2026-03-16", price: 300 },
    { date: "2026-03-15", price: 400 }
];

const avg = goldPrices
    .map(p => p.price)
    .reduce((sum, price, _, arr) => sum + price / arr.length, 0);

console.log("Avg price:", avg);