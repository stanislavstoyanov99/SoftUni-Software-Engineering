SELECT v, DENSE_RANK () OVER (ORDER BY v)
       rank_no
FROM   Sales