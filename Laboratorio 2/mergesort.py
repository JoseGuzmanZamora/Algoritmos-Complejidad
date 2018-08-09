#JOSÉ ALEJANDRO GUZMÁN ZAMORA
import math

contador_merge = 0
website_page_ranks = [3,39,61,91,57,22,75,89,9,90,63,78,28,73,20]

def merge(A, p, q, r):
    global contador_merge 
    n1 = q - p + 1
    n2 = r - q 
    L = [None] * (n1+1)
    R = [None] * (n2+1)
    for i in range(0, n1):
        L[i] = A[p+i]
    for j in range(0, n2):
        R[j] = A[q+(j+1)]
    L[n1] = math.inf
    R[n2] = math.inf
    v = 0
    w = 0
    tope = r-p+1
    for k in range(0, tope):
        contador_merge += 1 
        if L[v] <= R[w]:
            A[k+p] = L[v]
            v += 1
        else:
            A[k+p] = R[w]
            w += 1

def merge_sort(A,p,r):
    if p < r:
        q = math.floor((p+r)/2)
        merge_sort(A,p,q)
        merge_sort(A,q+1,r)
        merge(A,p,q,r)


merge_sort(website_page_ranks,0,14)
website_page_ranks = website_page_ranks[::-1]
print(website_page_ranks)
print("Cantidad de veces que iteró: ",contador_merge)

