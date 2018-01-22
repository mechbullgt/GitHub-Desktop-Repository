#include <bits/stdc++.h>

using namespace std;

vector < int > solve(int a0, int a1, int a2, int b0, int b1, int b2){
    int scorea,scoreb=0;
    vector<int> arr(6);
    arr={a0,a1,a2,b0,b1,b2};
    
    //    arr.push_back(a0);
    //    arr.push_back(a1);
    //    arr.push_back(a2);
    //    arr.push_back(b0);arr.push_back(b1);arr.push_back(b2);
    
    for (int i=0,j=3;i<3,j<6;i++,j++)
    {
        if(arr[i]>arr[j])
        {
            scorea = scorea+1;
        }
        else if( arr[i]<arr[j])
        {
            scoreb = scoreb+1;
        }
        else
        {
            scorea= scorea+0;
            scoreb=scoreb+0;
        }
    }
    vector<int> s(scorea,scoreb);
    
    return s;
}

int main() {
    int a0;
    int a1;
    int a2;
    cin >> a0 >> a1 >> a2;
    int b0;
    int b1;
    int b2;
    int scorea,scoreb=0;
    cin >> b0 >> b1 >> b2;
    
    vector < int > result = solve(a0, a1, a2, b0, b1, b2);
    
    //print result
    for (ssize_t i = 0; i < result.size(); i++) {
        cout << result[i] << (i != result.size() - 1 ? " " : "");
    }
    cout << endl;


    return 0;
}
