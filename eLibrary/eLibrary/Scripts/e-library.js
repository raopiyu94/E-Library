function ELibraryViewModel($scope, $http) {
    // declaring Customer object and its properties
    $scope.Book = {
        "bookName": "",
        "bookCost": "",
        "bookGenre": ""
    };
    // To watch an event anytime any changes occur // digest cycle
    
    $scope.Books = {};
    $scope.$watch("Books", function () {

        for (var x = 0; x < $scope.Books.length; x++) {
            var cust = $scope.Books[x]; 
            document.write(cust.bookName);
        }
    });
    /*
    // Return color according to amount passed
    $scope.getColor = function (Amount) {
        if (Amount == 0) {
            return "";

        }
        else if (Amount > 100) {
            return "Blue";
        }
        else {
            return "Red";
        }
    }
    
    // Call getColor function whenever Customer.CustomerAmount has any event occuring
    $scope.$watch("Customer.CustomerAmount", function () {
        $scope.Customer.CustomerAmountColor = $scope.
            getColor($scope.Customer.CustomerAmount);
    });
    */
    $scope.Add = function () {
        // make a call to server to add data
        // whenever .Add is called trigger Http POST method, data being passed is $scope.Customer 
        $http({ method: "Post", data: $scope.Book, url: "/api/Values" }).
            then(function (data, status, headers, config) {
                $scope.Books = data;
                $scope.Book = {
                    "bookName": "",
                    "bookCost": "",
                    "bookGenre": ""
                };
            });
    }

    $scope.Update = function () {
        // make a call to server to update data
        // To update always method:"PUT"
        $http({ method: "Put", data: $scope.Book, url: "/api/Values" }).
            then(function (data, status, headers, config) {
                $scope.Books = data;
                $scope.Book = {
                    "bookName": "",
                    "bookCost": "",
                    "bookGenre": ""
                };
            });
    }

    $scope.Delete = function () {
        // make a call to server to add data
        // this line is mandatory to perform any delete function
        $http.defaults.headers["delete"] = {
            'Content-Type': 'application/json;charset=utf-8'
        };
        $http({ method: "Delete", data: $scope.Book, url: "/api/Values" }).
            then(function (data, status, headers, config) {
                $scope.Books = data;
                $scope.Book = {
                    "bookName": "",
                    "bookCost": "",
                    "bookGenre": ""
                };
            });
    }

    // Very important
    $scope.Load = function () {
        $http({ method: "GET", url: "/api/Values" }).
            then(function (data, status, headers, config) {
                $scope.Books = data;

            });
    }

    $scope.LoadByName = function () {
        $http({
            method: "Get",
            url: "/api/Values?bookName=" + $scope.Book.bookName
        }).
            then(function (data, status, headers, config) {
                $scope.Books = data;

            });
    }

    $scope.LoadByGenre = function (bookGenre) {
        $http({
            method: "Get",
            url: "/api/Values?bookGenre=" + bookGenre
        }).
            then(function (data, status, headers, config) {
                $scope.Books = data;

            });
    }

    $scope.Load();
    // App
}
