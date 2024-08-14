import http from 'k6/http';
import { check, sleep } from 'k6';
export const options = {
    stages: [
        { duration: '5s', target: 2000 },
    ],
};
export default function () {
    const data = JSON.stringify({ name: "Hello RabbitMQ" })
    const res = http.post('http://localhost:5001/api/order/check-in/v2', data, {
        headers: { 'Content-Type': 'application/json' },
    });
    check(res, { 'status was 200': (r) => r.status == 200 });
    sleep(1);
}