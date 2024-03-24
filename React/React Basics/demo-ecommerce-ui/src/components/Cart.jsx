import React, { useEffect, useState } from 'react';
import { Card, Container, Row, Col, Button, Form, InputGroup } from 'react-bootstrap';
import axios from 'axios';
import { transformImagePath } from './TransformUrl';

const Cart = () => {
  const customerId = "cristiano@gmail.com";
  const [cart, setCart] = useState({});
  const [cartItems, setCartItems] = useState([]);

  // Function to fetch product details by ProductID
  async function fetchProductDetails(productId) {
    try {
      const response = await axios.get(`https://localhost:44382/api/Product/GetProductByproductID/${productId}`);
      response.data.ProductImage = transformImagePath(response.data.ProductImage); // Update the ProductImage here
      return response.data; // Assuming the API returns product details as JSON
    } catch (error) {
      console.error('Error fetching product details:', error);
      return null;
    }
  }

  // Function to update the quantity of a cart item
  async function updateCartItemQuantity(itemId, newQuantity) {
    try {
      const response = await axios.put('https://localhost:44382/api/CartItem/UpdateCartItemQuantity', {
        CartItemID: itemId,
        Quantity: newQuantity,
      });
      return response.data;
    } catch (error) {
      console.error('Error updating cart item quantity:', error);
      return null;
    }
  }

  useEffect(() => {
    // Get the active cart by customer ID
    axios.get(`https://localhost:44382/api/Cart/GetActiveCartByCustomerID/${customerId}`)
      .then((response) => {
        const data = response.data;
        setCart(data);

        // If a cart is found, get cart items
        if (data && data.CartID) {
          axios.get(`https://localhost:44382/api/CartItem/GetAllCartItemsByCartID/${data.CartID}`)
            .then(async (cartItemsResponse) => {
              const itemsData = cartItemsResponse.data;

              // Fetch product details for each cart item
              const itemsWithDetails = [];
              for (const item of itemsData) {
                const productDetails = await fetchProductDetails(item.ProductID);
                if (productDetails) {
                  itemsWithDetails.push({ ...item, Product: productDetails });
                }
              }

              setCartItems(itemsWithDetails);
            })
            .catch((error) => {
              console.error('Error fetching cart items:', error);
            });
        }
      })
      .catch((error) => {
        console.error('Error fetching cart:', error);
      });
  }, [customerId]);

  const handleIncrement = async (itemId) => {
    // Find the cart item to edit
    const itemToEdit = cartItems.find((item) => item.CartItemID === itemId);

    if (itemToEdit) {
      const newQuantity = itemToEdit.Quantity + 1;
      const updatedItem = await updateCartItemQuantity(itemId, newQuantity);

      if (updatedItem) {
        // Update the quantity locally
        itemToEdit.Quantity = newQuantity;
        setCartItems([...cartItems]);
      }
    }
  };

  const handleDecrement = async (itemId) => {
    // Find the cart item to edit
    const itemToEdit = cartItems.find((item) => item.CartItemID === itemId);

    if (itemToEdit && itemToEdit.Quantity > 1) {
      const newQuantity = itemToEdit.Quantity - 1;
      const updatedItem = await updateCartItemQuantity(itemId, newQuantity);

      if (updatedItem) {
        // Update the quantity locally
        itemToEdit.Quantity = newQuantity;
        setCartItems([...cartItems]);
      }
    }
  };

  return (
    <div className="bg-light" style={{ minHeight: '100vh' }}>
      <Container>
        <h2 className="my-4">Cart Items</h2>
        {cartItems.map((item) => (
          <Card key={item.CartItemID} className="my-3">
            <Card.Body>
              <Container>
                <Row>
                  <Col md={4}>
                    <Card.Img
                      variant="top"
                      src={item.Product.ProductImage}
                      alt={item.Product.ProductName}
                    />
                  </Col>
                  <Col md={8}>
                    <Row>
                      <Col>
                        <Card.Title>{item.Product.ProductName}</Card.Title>
                      </Col>
                    </Row>
                    <Row>
                      <Col>
                        <p>
                          Quantity:
                          <InputGroup style={{ width: '120px', textAlign: 'center',marginRight:'5px' }}>
                            <Button
                              variant="primary"
                              size="sm"
                              onClick={() => handleDecrement(item.CartItemID)}
                              // style={{marginRight:'10px',fontWeight:'bolder',fontSize:'30px',paddingTop:'1px', paddingRight:'20px', paddingLeft:'20px' }}
                            >
                              -
                            </Button>
                            <Form.Control
                              type="number"
                              value={item.Quantity}
                              onChange={(e) => {
                                const newQuantity = parseInt(e.target.value, 10);
                                if (!isNaN(newQuantity) && newQuantity >= 1) {
                                  handleIncrement(item.CartItemID);
                                }
                              }}
                              style={{ width: '30px', textAlign: 'center' }}
                            />
                            <Button
                              variant="primary"
                              size="sm"
                              onClick={() => handleIncrement(item.CartItemID)}
                            >
                              +
                            </Button>
                          </InputGroup>
                        </p>
                        <p>Total Price: ${item.TotalPrice}</p>
                      </Col>
                    </Row>
                  </Col>
                </Row>
              </Container>
            </Card.Body>
          </Card>
        ))}
      </Container>
    </div>
  );
};

export default Cart;
