import http from 'k6/http';
import { check } from 'k6';

export const options = {
  stages:[
  { duration: '30s', target: 20 },
]
};
export default function () {
    const params = {
        headers: {
            'accept': '*/*',
            'accept-encoding': 'gzip, deflate, br',
            'api-key': 'a6YLcU4na7FynLv5QJ8o2qvZQm7VXQ7zuffNB1KvodAzSeDI8GyY',
        },
    };
    const res = http.get('https://mino-search-test-acs.search.windows.net/indexes/ordersindex/docs?api-version=2021-04-30-Preview&search=1-373-659-7215&$top=10', params);
    check(res, {
      'is status 200': (r) => r.status === 200,
    });
}
