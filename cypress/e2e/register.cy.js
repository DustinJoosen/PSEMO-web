describe('Register', () => {

  it("Happy Path", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})

    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("Password1!", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "")
  });
  
  it("Does not work username not entered", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("Password1!", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "Gebruikersnaam is niet ingevuld")
  })

  it("Does not work email not entered", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})
  
    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("Password1!", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "Email is niet valide")
  })

  it("Does not work email not valid", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})
  
    cy.get("input#auth-form-email")
      .type("ongeldige email", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("Password1!", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "Email is niet valide")
  })

  it("Does not work password not entered", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})
  
    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("Password1!", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoorden zijn niet hetzelfde")
  })

  it("Does not work password confirmation not entered", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})
  
    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoorden zijn niet hetzelfde")
  })

  it("Does not work password not equal", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})
  
    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("Password2!", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoorden zijn niet hetzelfde")
  })

  it("Does not work password too short", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})
  
    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("pass", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("pass", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoord moet tenminste 6 tekens lang zijn")
  });

  it("Register does not work password no capital", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})
  
    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("password", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("password", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoord moet tenminste 1 hoofdletters hebben")
  })

    it("Register does not work password no num", () => {
    cy.visit("/auth/register");
    cy.wait(1000)

    cy.get("input#auth-form-username")
      .type("Syter6", { delay: 0})
  
    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password", { delay: 0})

    cy.get("input#auth-form-password-confirm")
      .type("Password", { delay:  0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoord moet tenminste 1 nummers hebben")
  })


});